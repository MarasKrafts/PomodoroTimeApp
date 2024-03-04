using System;
using System.Threading;
using NAudio.Wave;

public class PomodoroTimer
{
    private readonly int WorkDurationMinutes = 25;
    private readonly int RestDurationMinutes = 5;

    public void Start()
    {
        Console.WriteLine("Welcome to the Pomodoro Timer!");
        Console.WriteLine("Press any key to start working...");

        Console.ReadKey();

        Console.WriteLine($"Work session started! {WorkDurationMinutes} minutes of focused work...");

        WaitMinutes(WorkDurationMinutes);

        PlaySound(@"C:\Users\HELLO\Music\clock-alarm-8761.mp3");

        Console.WriteLine("Work session completed! Press any key to start your break...");

        Console.ReadKey();

        Console.WriteLine($"Rest session started! {RestDurationMinutes} minutes of relaxation...");

        WaitMinutes(RestDurationMinutes);

        PlaySound(@"C:\Users\HELLO\Music\alarm-clock-short-6402.mp3");

        Console.WriteLine("Rest session completed! Time to get back to work.");
    }

    private void PlaySound(string filePath)
    {
        try
        {
            using (var audioFile = new AudioFileReader(filePath))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();

                
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Thread.Sleep(100);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing sound: {ex.Message}");
        }
    }

    private void WaitMinutes(int minutes)
    {
        Thread.Sleep(TimeSpan.FromMinutes(minutes));
    }
}