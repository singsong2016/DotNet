  ---------------需要net framework 架构下
  //引用system.speech
  using System.Speech.Synthesis;

private static void SpeechDemo()
    {
        var a = new SpeechSynthesizer();

        var s = a.GetInstalledVoices();

        foreach (var installedVoice in s)
        {
            Console.WriteLine(installedVoice.VoiceInfo.Name);
        }

        a.SelectVoice("Microsoft Huihui Desktop");
        a.Speak("hello");
    }
