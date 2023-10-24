# ar-example-plugin

这是一个使用[AimRobot.Api](https://github.com/H4rry217/AimRobot-api)开发的插件，用于检测玩家每分钟的杀敌数，并在超过设定的最大值时踢出玩家。

## 功能

- 定义一个字典来存储每个玩家每分钟的杀敌数
- 定义一个常量表示每分钟允许的最大杀敌数（默认为10）
- 使用[AimRobot.Api.events](https://github.com/H4rry217/AimRobot-api)监听玩家杀死对方的事件
- 获取杀死对方的玩家的名字，并更新他们的杀敌数
- 计算上次检查以来经过的分钟数，并检查玩家是否

基于AimRobot.Api遵守AimRobot.Api的准则
- 不得使用[bfv robot]前缀
