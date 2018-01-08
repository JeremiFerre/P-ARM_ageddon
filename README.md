# P-ARM_ageddon
Polytech SI3 P-ARM Project

This project aims to simulate a simplified Cortex-M0 behavior using Logisim simulation program.



## Team Information

  * Team name: P-ARM_ageddon
  * Members:
    * [Jeremi Ferre](jeremi.ferre@etu.unice.fr)
    * [Gabriel Djebbar](gabriel.djebbar@etu.unice.fr)
    * [Laura Lopez](laura.lopez1@etu.unice.fr)
    * [Sebastien Tosello](sebastien.tosello@etu.unice.fr)
    * [Wei Wang](wei.wang@etu.unice.fr)


### Sommaire
 * Running the Assembly Parse
 * Load logisim file




**Running the Assembly Parser**

_On Linux:_
* Install mono-runtime package: 
	`sudo apt-get install mono-runtime`
* Untar the AssemblyParser_Linux.tar.gz file: 
	`tar zxvf AssemblyParser_Linux.tar.gz`
* Give execution permission: 
	`cd AssemblyParser_Linux`
	`chmod 700 p_arm_assemblyparser`
* Run the program:
	`./p_arm_assemblyparser <file_to_parse_path>`
	
_On Windows:_
* Untar the AssemblyParser_Windows.tar.gz file.
* Run PARM_AssemblyParser.exe with PowerShell or CMD:
	`.\PARM_AssemblyParser.exe <file_to_parse_path>`

**Load logisim filer**

  1. Open logisim
  2. Load `machine.circ`
  3. Right click on ROM -> load image
  4. Press 'CTRL-T'