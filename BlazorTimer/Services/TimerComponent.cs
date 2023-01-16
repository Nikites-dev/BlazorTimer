using System;
using System.Threading.Tasks;

namespace BlazorTimer.Services
{
    public class TimerComponent
    {
        private int currentCount = 300 * 1000;
        private String weather = "";
        public bool isFirst;
        public String Weather { get; set; }
        public Action NewAction { get; set; }

        public void DecrementCount()
        {
            long diffSeconds = currentCount / 1000 % 60;
                long diffMinutes = currentCount / (60 * 1000) % 60;
                long diffHours = currentCount / (60 * 60 * 1000) % 24;
        
                weather = $"{diffHours}ч. {diffMinutes}м. {diffSeconds}с.";
                Weather = weather;
                currentCount-=1000;
        }
    
        public async Task Timer() {
            while(currentCount >= 0) {
                DecrementCount();
                NewAction();

                await Task.Delay(1000);
            }
        }

        public void AddTime()
        {
            currentCount += 30 * 1000;
            NewAction();
           // StateHasChanged();
        }
    }
}