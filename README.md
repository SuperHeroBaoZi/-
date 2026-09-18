# uppercase.exe

将英文小写字母 `a-z` 转为 `A-Z`，中文、数字、标点、空格、换行和其他字符保持不变。不会额外添加换行。

可执行文件位于桌面 `uppercase.exe`。使用 Windows 自带的 .NET Framework 4.x，不需要安装 Python。

在桌面打开 PowerShell：

```powershell
.\uppercase.exe 'Hello 世界 123!'
# 输出：HELLO 世界 123!

'hello world' | .\uppercase.exe
.\uppercase.exe --help
```

含空格的字符串必须用引号包围。PowerShell 单引号可以避免 `$` 等字符被解释。无参数时从标准输入读取，管道输入输出采用 UTF-8；管道上游添加的换行会保留。Windows PowerShell 5.1 若要通过管道传递中文，请先设置 `$OutputEncoding = [System.Text.UTF8Encoding]::new($false)`。

在其他目录使用时，可以指定 exe 的完整路径，或将它所在目录加入 PATH。

重新编译（在本目录运行）：

```powershell
& "$env:WINDIR\Microsoft.NET\Framework64\v4.0.30319\csc.exe" /nologo /optimize+ /target:exe /out:..\uppercase.exe Program.cs
```
