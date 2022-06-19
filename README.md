# Xmouse
 方便的切换鼠标左右键，因为功能非常简单，所以支持.net framework 2.0及以上 windows环境就可以了，目前已测试win7可用，反正我一直在用了。

 关于为什么做这么个东西，那是因为我右手疼，目前只能用左手鼠标好多年，不是左撇子（囧)，所以这个东西只对极少部分人有用，如果经常切换左右手，那就非常好用，这个软件作为自己的一个小作品留个自己的左撇子儿子，他的爸爸很爱他，用程序员的方式为他留了一件用心制作的礼物。

 目前最新的版本升级到1.2，支持托盘和快捷方式了，这个版本基本之后基本不会有大的更新了。
 
 产品目录结构如下：
 只有一个Xmouse.exe 和2个箭头相反的鼠标文件格式，2个鼠标文件是非必须选项，左手鼠标箭头就朝右上角，右手反之。
 
 ![image](screenshot/menu.png)

# 使用方法
- 1、运行Xmouse.exe，程序就会判断鼠标的左右手设置，如果是右手那么自动切换到左手。

![image](screenshot/left-hand.png)

- 2、如果是系统设置是左手则自动设置为右手。

![image](screenshot/right-hand.png)

- 3、点击文字左右侧的小手也可以实时切换左右手。
- 4、运行之后右下角会有托盘，托盘上可以通过鼠标进行切换左右手
![image](screenshot/tray.png)
- 5、通过快捷键 Alt+L 切换到左手鼠标，快捷键 Alt+R 切换到右手鼠标，切换的时候在屏幕上会有提示，3秒后提示自动关闭
![image](screenshot/shortcut-left-hand.jpg)

- 6、联系作者
点击关于大家可以通过邮件、微信公众号、微博，twitter，以及github联系到我
 ![image](screenshot/about.png)


# 技术
- 开发工具 `visual studio 2017 RC版本` 
- markdown 工具 `visual studio code` 
- .net 版本 `2.0`
- 调用组件 `user32.dll`
- 代码管理 `git`

# 下载
 [下载地址](https://github.com/robotbird/Xmouse/releases) 
# 关于作者
不会写代码的产品经理不是好售前。个人博客 [jqpress.com](http://www.jqpress.com)，微信公众号：产品经理与狗
![image](Xmouse/img/PMAndDog.jpg)
