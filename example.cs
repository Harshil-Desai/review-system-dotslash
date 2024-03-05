using System;
using System.Collections.Generic;

public class SentCommand
{
    public string command { get; set; }
    public bool isResponseReceived { get; set; }
    public DateTime respondReceivedAt { get; set; }
    public DateTime sendAt { get; set; }
    public bool isCommandSend { get; set; }
}

public class DeviceSettingData
{
    public int ecmap { get; set; }
    public int offset { get; set; }
    public int slope { get; set; }
    public int aux_b { get; set; }
    public int act_b { get; set; }
    public int sen_m { get; set; }
    public int sen_m_second { get; set; }
}

public class PmSensorSettingsData
{
    public int offset_PM_1_0 { get; set; }
    public int slope_PM_1_0 { get; set; }
    public int offset_PM_2_5 { get; set; }
    public int slope_PM_2_5 { get; set; }
    public int offset_PM_10 { get; set; }
    public int slope_PM_10 { get; set; }
}

public class AuxSensorData
{
    public int aux_offset { get; set; }
    public int aux_slope { get; set; }
}

public class Devicesettings
{
    public int echemnum { get; set; }
    public List<DeviceSettingData> echem_sensor_settings_data { get; set; }
    public int pmnum { get; set; }
    public int pmtype { get; set; }
    public List<PmSensorSettingsData> pm_sensor_settings_data { get; set; }
    public int autorange { get; set; }
    public int constrain_op { get; set; }
    public int co2sel { get; set; }
    public AuxSensorData aux_sensor_data { get; set; }
    public int meten { get; set; }
    public int windfilter { get; set; }
    public int sdrate { get; set; }
    public int usbmode { get; set; }
    public int adj { get; set; }
    public int data_delay { get; set; }
    public int gpsmode { get; set; }
    public int protocol { get; set; }
    public int ratio { get; set; }
    public int autotime { get; set; }
    public int cellmode { get; set; }
    public string serv_adrs { get; set; }
    public string apn { get; set; }
    public int carrier { get; set; }
    public string customband { get; set; }
    public int sslmode { get; set; }
    public int tzone { get; set; }
    public int datatype { get; set; }
    public int mqttv { get; set; }
    public string publish { get; set; }
    public string subscribe { get; set; }
}

public class SPODDevicesettings
{
    public int data_delay { get; set; }
    public int stream { get; set; }
    public int cellmode { get; set; }
    public int ratio { get; set; }
    public int gpsmode { get; set; }
    public int acpower { get; set; }
    public int autotime { get; set; }
    public string apn { get; set; }
    public string serv_adrs { get; set; }
    public int protocol { get; set; }
    public int sslmode { get; set; }
}

public class RootObject
{
    public string uuid { get; set; }
    public string key { get; set; }
    public string name { get; set; }
    public string location { get; set; }
    public string sensorLat { get; set; }
    public string ref1Lat { get; set; }
    public string ref2Lat { get; set; }
    public string sensorLng { get; set; }
    public string ref1Lng { get; set; }
    public string ref2Lng { get; set; }
    public string picture { get; set; }
    public string status { get; set; }
    public string type { get; set; }
    public string orientation { get; set; }
    public bool isUTCTimeZone { get; set; }
    public int timezone { get; set; }
    public DateTime createdDate { get; set; }
    public DateTime lastUpdated { get; set; }
    public string createdBy { get; set; }
    public string updatedBy { get; set; }
    public bool isDeleted { get; set; }
    public bool isFirmwareUpdateRequire { get; set; }
    public List<SentCommand> sentCommands { get; set; }
    public string settingCRC { get; set; }
    public Devicesettings devicesettings { get; set; }
    public SPODDevicesettings SPODDevicesettings { get; set; }
    public string temp_settings { get; set; }
    public string temp_settings_crc { get; set; }
    public string temp_settings_whole_packet { get; set; }
    public string temp_settings_whole_packet_crc { get; set; }
    public bool isDateChached { get; set; }
    public object lastReceivedRecord { get; set; }
}
