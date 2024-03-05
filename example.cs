  uuid: {
    type: String,
    required: true,
    trim: true,
    sparse: true,
  },
  key: {
    type: String,
    required: false,
    trim: true,
  },
  name: {
    type: String,
    required: true,
    trim: true,
  },
  location: {
    type: String,
    trim: true,
  },
  sensorLat: {
    type: String,
    trim: true,
  },
  ref1Lat: {
    type: String,
    trim: true,
  },
  ref2Lat: {
    type: String,
    trim: true,
  },
  sensorLng: {
    type: String,
    trim: true,
  },
  ref1Lng: {
    type: String,
    trim: true,
  },
  ref2Lng: {
    type: String,
    trim: true,
  },
  picture: {
    type: String,
    trim: true,
  },
  status: {
    type: String,
    enum: ['Active', 'Disabled'],
  },
  type: {
    type: String,
    enum: ['FPL', 'SPOD', 'RAMP', 'FMD'],
  },
  orientation: {
    type: String,
    trim: true,
  },
  isUTCTimeZone: {
    type: Boolean,
  },
  timezone: {
    type: Number,
  },
  createdDate: {
    type: Date,
    required: false,
    default: new Date(),
  },
  lastUpdated: {
    type: Date,
    required: false,
    default: new Date(),
  },
  createdBy: {
    type: mongoose.Schema.Types.ObjectId,
    required: false,
  },
  updatedBy: {
    type: mongoose.Schema.Types.ObjectId,
    required: false,
  },
  isDeleted: {
    type: Boolean,
    required: false,
    default: false,
  },
  isFirmwareUpdateRequire: {
    type: Boolean,
    required: false,
    default: false,
  },
  sentCommands: [
    {
      command: {
        type: String,
        required: true,
        trim: true,
      },
      isResponseReceived: {
        type: Boolean,
        required: true,
      },
      respondReceivedAt: {
        type: Date,
        required: true,
      },
      sendAt: {
        type: Date,
        required: true,
      },
      isCommandSend: {
        type: Boolean,
        required: true,
      },
    },
  ],
  settingCRC: {
    type: String,
  },
  devicesettings: {
    echemnum: {
      type: Number,
    },
    echem_sensor_settings_data: [
      {
        ecmap: {
          type: Number,
        },
        offset: {
          type: Number,
        },
        slope: {
          type: Number,
        },
        aux_b: {
          type: Number,
        },
        act_b: {
          type: Number,
        },
        sen_m: {
          type: Number,
        },
        sen_m_second: {
          type: Number,
        },
      },
    ],
    pmnum: {
      type: Number,
    },
    pmtype: {
      type: Number,
    },
    pm_sensor_settings_data: [
      {
        offset_PM_1_0: {
          type: Number,
        },
        slope_PM_1_0: {
          type: Number,
        },
        offset_PM_2_5: {
          type: Number,
        },
        slope_PM_2_5: {
          type: Number,
        },
        offset_PM_10: {
          type: Number,
        },
        slope_PM_10: {
          type: Number,
        },
      },
    ],
    autorange: {
      type: Number,
    },
    constrain_op: {
      type: Number,
    },
    co2sel: {
      type: Number,
    },
    aux_sensor_data: {
      aux_offset: {
        type: Number,
      },
      aux_slope: {
        type: Number,
      },
    },
    meten: {
      type: Number,
    },
    windfilter: {
      type: Number,
    },
    sdrate: {
      type: Number,
    },
    usbmode: {
      type: Number,
    },
    adj: {
      type: Number,
    },
    data_delay: {
      type: Number,
    },
    gpsmode: {
      type: Number,
    },
    protocol: {
      type: Number,
    },
    ratio: {
      type: Number,
    },
    autotime: {
      type: Number,
    },
    cellmode: {
      type: Number,
    },
    serv_adrs: {
      type: String,
    },
    apn: {
      type: String,
    },
    carrier: {
      type: Number,
    },
    customband: {
      type: String,
    },
    sslmode: {
      type: Number,
    },
    tzone: {
      type: Number,
    },
    datatype: {
      type: Number,
    },
    mqttv: {
      type: Number,
    },
    publish: {
      type: String,
    },
    subscribe: {
      type: String,
    },
  },
  SPODDevicesettings: {
    data_delay: {
      type: Number,
    },
    stream: {
      type: Number,
    },
    cellmode: {
      type: Number,
    },
    ratio: {
      type: Number,
    },
    gpsmode: {
      type: Number,
    },
    acpower: {
      type: Number,
    },
    autotime: {
      type: Number,
    },
    apn: {
      type: String,
    },
    serv_adrs: {
      type: String,
    },
    protocol: {
      type: Number,
    },
    sslmode: {
      type: Number,
    },
  },
  temp_settings: {
    type: String,
  },
  temp_settings_crc: {
    type: String,
  },
  temp_settings_whole_packet: {
    type: String,
  },
  temp_settings_whole_packet_crc: {
    type: String,
  },
  isDateChached: {
    type: Boolean,
    required: false,
    default: false,
  },
  lastReceivedRecord: {
    type: Object,
    required: false,
    default: true,
  },
});
