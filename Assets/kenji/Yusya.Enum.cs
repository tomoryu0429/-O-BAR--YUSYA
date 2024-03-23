using UnityEngine;
namespace Yusya.Enum
{
    public enum MonsterKey
    {
        ID,
        Name,
        HP,
        DropM,
        DropC
    }

    public enum HPStatus
    {
        Pramater = 1,
    }

    public enum ATAtatus
    {
        Pramater = 1,
    }

    public enum DropC
    {
        [InspectorName("�[���[")] Gelatin,
        [InspectorName("�L�m�R")] Mushroom
    }
}
