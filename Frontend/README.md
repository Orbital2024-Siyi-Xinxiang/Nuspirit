Currently, this App runs much more smoothly on physical iPhone devices than on Xcode Simulator. 
Here is a step-by-step guide of how to load NUSpirit on your own iPhone devices. 

1. Open any Terminal window from your Laptop, navigate to the directory where you want the app project to be downloaded

2. After entering the directory you want, enter “git clone https://github.com/Orbital2024-Siyi-Xinxiang/Nuspirit.git” in terminal and press enter. Wait for download to finish. 

3. Find the Xcode project from NUSprit > Frontend > Orbital.xcodeproj. Double click the file to open or manually open it with Xcode 

4. After entering the project, connect your physical iPhone Device to your Laptop using a data cable, after that you will be able to see your Device’s name from the small drop-down list of simulators at the middle top of the Xcode window. 

5. Select your device name. Make sure the project name on the left of your device is “Orbital” with a brown-green icon. 

6. Press the ▶️ button at the top left of the window. Wait for build to finish. You can observe the progress of the building on the right of your device name. 

7. If Build fails, please do the following: 
    a. Go to Product > Clean Build Folder > Clean 
    b. Go to file > Packages > Reset Package Caches 
    c. Open Finder, press shift + command + G, enter "~/Library/Developer/Xcode/DerivedData" in the box and delete everything in the DerivedData folder (no worries, this will not affect your divice)
    d. Try step 6 to build the app again. 
    
8. After build finish, an app named “Orbital” will appear on your iPhone Screen. The features currently available are: SignIn, SignUp, Map, Furniture Market and part of the Settings.

9. If you face any issue during the process, pls contact Xinxiang @Xinxiang379 or Siyi @Siyi_Xu via Telegram. Thanks a lot for your patience and feedback!!
