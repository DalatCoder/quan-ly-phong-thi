using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [Serializable]
    public enum DataContainerType
    {
        PhatDe,
        ThuBai,
        LuuBaiODau,
        GuiThongBaoAll,
        GuiDanhSachSV,
        GuiSinhVien,
        DiemDanhSinhVien,
        GuiThongTinDiemDanh,
        BatDauLamBai,
        GuiThoiGianLamBai,
        CamChuongTrinh,
        SendList,
        SendStudent,
        SendString,
        SendPcName,
        DisconnectAll,
        BeginExam,
        FinishExam,
        LockClient,
        UnlockClient,
        Shutdown,
        Restart,
        Undefined
    }

    [Serializable]
    public class DataContainer
    {
        public DataContainerType Type { get;  set; }
        public object Data { get;  set; }

        public DataContainer()
        {
            Type = DataContainerType.Undefined;
            Data = null;
        }

        public DataContainer(DataContainerType Type, object Data)
        {
            this.Type = Type;
            this.Data = Data;
        }

        public byte[] Serialize()
        {
            if (Type.HasFlag(DataContainerType.Undefined))
                throw new Exception("Response is invalid");

            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, this);

            return stream.ToArray();
        }

        public static DataContainer Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            object obj = formatter.Deserialize(stream);

            return obj as DataContainer;
        }
    }
}
