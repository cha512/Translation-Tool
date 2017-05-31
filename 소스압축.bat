@ECHO OFF
CLS
7z.exe a "./TranslationTool_%date:-=%%time:~0,2%%time:~3,2%%time:~6,2%"
PAUSE