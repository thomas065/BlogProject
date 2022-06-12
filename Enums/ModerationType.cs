using System.ComponentModel;

namespace BlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Political propaganda")]
        Political,
        [Description("Offensive Language")]
        Language,
        [Description("Drug references")]
        Drugs,
        [Description("Hate Speech")]
        HateSpeech,
        [Description("Sexual speech")]
        Sexual,
        [Description("Threatening Speech")]
        Threatening,
        [Description("Targeted bullying")]
        Bullying
    }
}
