# MobileEye

### Quick overview
<p align="justify" style="line-height:200%;">
The PicAnalyzer was built using Visual Studio to facilitate the coding of fixated Regions Of Interest (ROIs) during mobile eye tracking experiments. The current implementation is applicable for four mutually exclusive ROIs – head, body, surroundings, invalid fixation. Additionally, it contains a checkbox indicating whether a person is present in the picture. The numbers of buttons and checkboxes can be easily adjusted and names can be replaced in the corresponding code (see <a href="https://github.com/lara-roe/MobileEye/blob/master/PicAnalyzer/PicAnalyzer.sln">PicAnalyzer.sln</a>). 
</p>

<img src="https://github.com/lara-roe/MobileEye/blob/master/Example_Image.png" width="100%">

</br>

### Necessary data format
<p align="justify" style="line-height:200%;">
In order to be able to adequately use the PicAnalyzer, the videos need to be already split into their respective frames. The application was programmed in such a way that the name of the overarching folder containing all the frame pictures will be used for the designation of the output file name and all entries of its first column. The length can accordingly be adjusted in the software code (currently set to two characters).
</p>

</br>

### How to use the PicAnalyzer.exe
<p align="justify" style="line-height:200%;">
The button names of the PicAnalyzer explain most of its functions. Via the “Choose Subject” button all images that are to be coded of the specific participant can be loaded into the Analyzer (here ctrl + alt is usually the best way to go). The radio buttons and checkboxes can consequently be used to code which areas of the image were looked at by the participant. The checkbox will remain checked across frames unless it is unchecked. Similarly,  the chosen radio button (head, body, surroundings or invalid fixation) will remain selected. If the corresponding ROI was indeed still fixated, the “Next Image” can be used to load the next image. If a different radio button is chosen, the next image will  automatically be loaded, saving a click. Checking or unchecking the checkbox does not trigger the next image to appear. If a wrong ROI was accidentally selected the “Previous Image” button can be clicked and the button coding the frame can be selected anew. The “Save/Close”-Button can be used to save and close the app. It will automatically trigger a saving and close when all of the loaded images were coded. The PicAnalyzer yields a csv-file saving participant name, image name, and the chosen buttons (indicated by 1, all other buttons are coded 0) for each frame which can be used for further analyses. Click <a href="https://github.com/lara-roe/MobileEye/blob/master/01.csv">here</a> for an example output file.
</p>
