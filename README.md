# NUS Orbital 2024
# Nuspirit
## A multi-functional study metaverse for NUS students
### Introduction
### Poster
### Core Features
### UserStories

## Repo Structure
This repo consists of one integrated workspace, two xcode projects(native swiftUI app & ios app built from unity project) and one native unity project. This separation of microservices is for optimization of ios performance. Due to native firebase SDK issues, current framework embedding solution doesn't work. (Refer to the single-feature documentations here: )

### For testing out unity project alone:
Unity project is located in 

## Prototype Testing
### Download
ios:
Nuspirit native app:
UnityScene app:
**** For performance optimization, Nuspirit is implement in two microservice apps, one in swiftUI one built from unity. Please download both to enjoy all features!

Android:(adapated from native ios)

App Testing Instructions

Currently, this App runs much more smoothly on physical iPhone devices than on Xcode Simulator. 
Here is a step-by-step guide of how to load NUSpirit on your own iPhone devices. 

1. Open any Terminal window from your Laptop, navigate to the directory where you want the app project to be downloaded

2. After entering the directory you want, enter “git clone https://github.com/Orbital2024-Siyi-Xinxiang/Nuspirit.git” in terminal and press enter. Wait for the download to finish.

4. Find the Xcode project from NUSprit > Frontend > Orbital.xcodeproj. Double click the file to open or manually open it with Xcode

6. Find the Xocde project from NUSpirit > UnityScenes > iosBuild, directly open this workspace and set active scheme to 'Unity-iPhone'.

7. After entering the project, connect your physical iPhone Device to your Laptop using a data cable, after that you will be able to see your Device’s name from the small drop-down list of simulators at the middle top of the Xcode window. 

8. Select your device name. Make sure the scheme name on the left of your device is “Orbital” with a brown-green icon. 

9. Press the ▶️ button at the top left of the window. Wait for the build to finish. You can observe the progress of the building on the right of your device name. 

10. Then turn to another Xcode project (the unity iphone one), make sure the scheme name is 'Unity-iPhone' and build.
    
11. If Build fails, please do the following: 
    a. Go to Product > Clean Build Folder > Clean 
    b. Go to file > Packages > Reset Package Caches 
    c. Open Finder, press shift + command + G, enter "~/Library/Developer/Xcode/DerivedData'' in the box and delete everything in the DerivedData folder (no worries, this will not affect your device)
    d. Try step 6 to build the app again. 
    
12. After the build finishes, an app named “Orbital” will appear on your iPhone Screen. The features currently available are: SignIn, SignUp, Map, Furniture Market and part of the Settings. The Unity scene hasn’t been integrated into the workspace yet.

13. If you face any issue during the process, pls contact Xinxiang @Xinxiang379 or Siyi @Siyi_Xu via Telegram. Thanks a lot for your patience and feedback!!


Common problems and reminders:
*Please select automatic signing certificate in signing & certificate target settings.
*In case a provisioning profile is still needed, please select team Siyi Xu (Log in to siyi’s apple developer account first)  Team ID  95G7HLQQGC    Program  Apple Developer Program
Contact @Siyi_Xu for apple ID and passwords!



### Environmental Setup
to run backend server:

run in terminal
```ruby
cd Backend
node server.js
```

### Other Configurations
When running xcode projects from xcode, make sure:
provisioning profile is set correctly(refer to app testing documentation here: )
xcoede version ~14.0

## README And Documentations

## Analytics
### Usage of Firebase Data:
### App Performance
### Testing

## Administrative Information
Team Name: Nuspirit
Programme Name: NUS Orbital 2024
Level Of Achievement: Artemis
### Contact Information
If encountered any issue related to app testing and request of resource, please refer to the contact information below:
Email: e1300538@u.nus.edu
Person In Charge: Siyi Xu
HP: 83878720
