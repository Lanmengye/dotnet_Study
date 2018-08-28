## 程序集
1. 程序集的介绍
  - 程序集是.net中的概念
  - .net中的exe和dll都是程序集
  - 程序集可以看做是一堆相关类打一个包，相当于java中的jar包
2. 程序集包含的内容
  - 类型元素据：描述在代码中定义的每一类型和成员，二进制形式
  - 程序集元数据： 程序集清单、版本号、名称等
  - IL代码
  - 资源文件
    每个程序集都有自己的名称、版本等信息。这些信息可以通过AssemblyInfo.cs文件来自己定义
3. 使用程序集的好处
  - 程序中只引用必要的程序集，减少程序的尺寸
  - 程序集可以封装一些代码，只提供必要的访问接口。
4. 添加程序集引用
    - 添加路径、项目引用、GAC（全局程序集缓存）
      - 不能循环添加引用

      - 在C#中添加其他语言编写的dll的文件的应用。

## 常用术语及简称

- CIL/IL(Common Intermediate Language)：(公共)中间语言
- CLR(Common Language Runtime): 公共语言运行时
- VES(Virtual Execution System): 虚拟执行系统
- JIT(Just-in-time compilation) 即时编译
- CLI(Common Language Infrastructure): 公共语言基础结构
	* VES或运行时
	* CIL
	* 公共类型系统(Common Type System, CTS)
	* 公共语言规范(Common Language Specification, CLS)
	* 元数据
	* 基类库(Base Class Library, BCL)  

- 公共语言基础结构的作用：

    * 语言互操作性
    * 类型安全
    * 代码访问安全性
    * 垃圾回收
    * 平台可移植性
    * BCL

- 托管代码(manage code)/托管执行(manage execution)
- 本机代码(native code)/非托管代码(unmanaged code) 

- CIL和ILDASM
C#编译器将C#代码转换成CIL代码而不是机器码。给定一个程序集（DLL文件或可执行文件）可以使用CIL反汇编程序将其析构成对应的CIL表示，从而查看其IL代码。
