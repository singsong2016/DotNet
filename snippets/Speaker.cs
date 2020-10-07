 public static class Speaker
    {
        public static void Speak(string str)
        {
            var voice = new SpVoice();

            voice.Rate = 1;

            voice.Volume = 70;

            voice.Voice = voice.GetVoices().Item(2);

            Console.WriteLine(str);
            voice.Speak(str);
           

        }
    }
