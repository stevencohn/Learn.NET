::================================================================================================
:: Enable or disable automatic crash dump file creation
:: To enabled - run without parameters 
:: To disable - run with the parameter: disable
::================================================================================================

@echo off
setlocal

echo.
set key=HKLM\Software\Microsoft\Windows\Windows Error Reporting\LocalDumps

if /i "%1" equ "disable" goto DisableDumps

:EnableDumps
set target=C:\Crash
if not exist "%target%" (
  mkdir "%target%"
  echo ... Created folder %target%
) else (
  echo ... '%target%' already exists
)

reg add "%key%" /v DumpFolder /t REG_EXPAND_SZ /d "C:\Crash" /f 1>nul 2>&1
if %errorlevel% neq 0 goto ShowError

reg add "%key%" /v DumpType /t REG_DWORD /d 2 /f 1> nul 2>&1
if %errorlevel% neq 0 goto ShowError

echo ... Local crash dumps enabled
goto :EOF

:DisableDumps
reg delete "%key%" /f 1>nul 2>&1
if %errorlevel% neq 0 goto ShowError
echo ... Local crash dumps disabled
goto :EOF


:ShowError
echo *** Error updating registry.
echo *** Try running this from an administrative command prompt.
goto :EOF

