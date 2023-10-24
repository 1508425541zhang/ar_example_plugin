using AimRobot.Api;
using AimRobot.Api.events;
using AimRobot.Api.events.ev;
using System;
using System.Collections.Generic;

namespace ar_example_plugin
{
    public class MyPluginEventListener : IEventListener
    {
        // 使用成员变量来代替高频率出现的局部变量[^1^][1]
        private Dictionary<string, int> killsPerMinute = new Dictionary<string, int>();

        // 定义一个常量表示每分钟允许的最大杀敌数
        private const int MAX_KILLS_PER_MINUTE = 2;

        // 定义一个DateTime变量来存储上次检查时间
        private DateTime lastCheckTime = DateTime.UtcNow;

        [AimRobot.Api.events.EventHandler]
        public void whenPlayerDeathEvent(PlayerDeathEvent eventArgs)
        {
            // 获取杀死对方的玩家的名字
            string playerName = eventArgs.killerName;

            // 如果玩家不在字典中，添加他们并赋值为0
            if (!killsPerMinute.ContainsKey(playerName))
            {
                killsPerMinute[playerName] = 0;
            }

            // 增加玩家的杀敌数
            killsPerMinute[playerName]++;

            // 计算上次检查以来经过的秒数
            int secondsSinceLastCheck = (int)(DateTime.UtcNow - lastCheckTime).TotalSeconds;

            // 检查玩家是否超过了每分钟允许的最大杀敌数
            if (killsPerMinute[playerName] / secondsSinceLastCheck > MAX_KILLS_PER_MINUTE)
            {
                // 踢出玩家
                Robot.GetInstance().KickPlayer(eventArgs.killerName, "你已经超过了每分钟允许的最大杀敌数2，kpm<2");
            }

            // 更新上次检查时间
            lastCheckTime = DateTime.UtcNow;
        }
    }
}
