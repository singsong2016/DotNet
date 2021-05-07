  ---------------需要net framework 架构下
  
  
  public static void SpeechDemo(string str)
        {
            var voice = new SpVoice
            {
                Rate = 1,

                Volume = 70
            };

            voice.Voice = voice.GetVoices().Item(1);

            Console.WriteLine(str);
            voice.Speak(str);


        }
