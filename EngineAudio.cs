using UnityEngine;
using VehiclePhysics;

public class EngineAudio : MonoBehaviour
{
    public AK.Wwise.Event EngineSound;
    public AK.Wwise.Event EngineStop;

    bool StartSound;
    public string RPM; // параметр RPM
    public string Throttle; // параметр загрузки двигателя
    // public string Acceleration;   // параметр впрыска
    public string OverRev; //перегрев двигла

    public VehicleBase vehicle;

    #region Car_Parameters
    float Ignition;
    float engineRpm;
    float engineLoad;
    float EngineStart;
    float EngineStalled;
    float overrev;
#endregion

    void Awake()
    {
       vehicle = GetComponent<VehicleBase>();
    }

    void Start()
    {
        StartSound = false; // контроль для избежания повтора звуков двигателя.
    }

    void Update()
    {
        CarStates();
        EngineStarting();
        SoundStates();

        print(overrev);

    }

    void EngineStarting()
    {

        if ((EngineStalled == 1f) && (engineLoad > 0f) && (StartSound == false))
        {
            EngineSound.Post(gameObject);
            print("PlaySound");
            StartSound = true;
        }

        if (engineRpm == 0)
        {
            EngineStop.Post(gameObject);
            print("Stopped");
            StartSound = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))

        { EngineStop.Post(gameObject);
            StartSound = false;
        }
    }
        void CarStates()
        {
            Ignition = vehicle.data.Get(Channel.Vehicle, InputData.Key);           // Зажигание измеряется в значениях -1/0/1
            engineRpm = vehicle.data.Get(Channel.Vehicle, VehicleData.EngineRpm) / 1000.0f;   //Обороты rpm 6750 (для себя отперелил такой максимум, в игре может идти и больше)
            engineLoad = vehicle.data.Get(Channel.Vehicle, VehicleData.EngineLoad) / 1000.0f; // Двигатель под нагрузкой в процентах до 100%. значения от 0 до 1
            EngineStart = vehicle.data.Get(Channel.Vehicle, VehicleData.EngineWorking);   //Состояние работает ли двигатель в единицах 0-1
            EngineStalled = vehicle.data.Get(Channel.Vehicle, VehicleData.EngineStalled); //Состояние холостой ход  в единицах0-1
            overrev = vehicle.data.Get(Channel.Vehicle, VehicleData.EngineLimiter);       // Перегрев в единицах 0-1

        }
    void SoundStates()
    {

        AkSoundEngine.SetRTPCValue(Throttle, engineLoad);
        AkSoundEngine.SetRTPCValue(OverRev, overrev);

        //RPM
        if (engineRpm > 6750)
        { AkSoundEngine.SetRTPCValue(RPM, 6750); }
        else  AkSoundEngine.SetRTPCValue(RPM, engineRpm);
    }
    }
