@echo off
setlocal

for /D %%v in (*.*) do (
  pushd %%v
  echo Cleaning %%v ...
  if exist bin\nul rmdir /s /q bin
  if exist obj\nul rmdir /s /q obj
  if exist .vs\nul rmdir /s /q .vs
  popd
)

endlocal
echo.
pause
