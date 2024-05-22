# Nuspirit

For orbital 2024

to run backend server:

run in terminal

```ruby
cd Backend
node server.js
```

this is the official api given by google firebase:
let authViewController = authUI.authViewController()
After you present the authentication view and the user signs in, the result is returned to the FirebaseUI Auth delegate in the didSignInWithUser:error: method:

Swift
Objective-C

func authUI(_ authUI: FUIAuth, didSignInWith user: FIRUser?, error: Error?) {
  // handle user and error as necessary
}Sign Out
FirebaseUI provides convenience methods to sign out of Firebase Authentication as well as all social identity providers:

Swift
Objective-C

authUI.signOut()



Listen for authentication state
For each of your app's views that need information about the signed-in user, attach a listener to the FIRAuth object. This listener gets called whenever the user's sign-in state changes.

Attach the listener in the view controller's viewWillAppear method:

Swift
Objective-C

handle = Auth.auth().addStateDidChangeListener { auth, user in
  // ...
}

And detach the listener in the view controller's viewWillDisappear method:

Swift
Objective-C

Auth.auth().removeStateDidChangeListener(handle!)

Sign up new users
Create a form that allows new users to register with your app using their email address and a password. When a user completes the form, validate the email address and password provided by the user, then pass them to the createUser method:

Swift
Objective-C

Auth.auth().createUser(withEmail: email, password: password) { authResult, error in
  // ...
}

Sign in existing users
Create a form that allows existing users to sign in using their email address and password. When a user completes the form, call the signIn method:

Swift
Objective-C

Auth.auth().signIn(withEmail: email, password: password) { [weak self] authResult, error in
  guard let strongSelf = self else { return }
  // ...
}

Get user information
After a user signs in successfully, you can get information about the user. For example, in your authentication state listener:

Swift
Objective-C

if let user = user {
  // The user's ID, unique to the Firebase project.
  // Do NOT use this value to authenticate with your backend server,
  // if you have one. Use getTokenWithCompletion:completion: instead.
  let uid = user.uid
  let email = user.email
  let photoURL = user.photoURL
  var multiFactorString = "MultiFactor: "
  for info in user.multiFactor.enrolledFactors {
    multiFactorString += info.displayName ?? "[DispayName]"
    multiFactorString += " "
  }
  // ...
}

Get the currently signed-in user
The recommended way to get the current user is by setting a listener on the Auth object:

Swift
Objective-C

handle = Auth.auth().addStateDidChangeListener { auth, user in
  // ...
}
By using a listener, you ensure that the Auth object isn't in an intermediate state—such as initialization—when you get the current user.

You can also get the currently signed-in user by using the currentUser property. If a user isn't signed in, currentUser is nil:

Swift
Objective-C

if Auth.auth().currentUser != nil {
  // User is signed in.
  // ...
} else {
  // No user is signed in.
  // ...
}
Note: currentUser might also be nil because the auth object has not finished initializing. If you use a listener to keep track of the user's sign-in status, you don't need to handle this case.
Get a user's profile
To get a user's profile information, use the properties of an instance of FIRUser. For example:

Swift
Objective-C

let user = Auth.auth().currentUser
if let user = user {
  // The user's ID, unique to the Firebase project.
  // Do NOT use this value to authenticate with your backend server,
  // if you have one. Use getTokenWithCompletion:completion: instead.
  let uid = user.uid
  let email = user.email
  let photoURL = user.photoURL
  var multiFactorString = "MultiFactor: "
  for info in user.multiFactor.enrolledFactors {
    multiFactorString += info.displayName ?? "[DispayName]"
    multiFactorString += " "
  }
  // ...
}
Get a user's provider-specific profile information
To get the profile information retrieved from the sign-in providers linked to a user, use the providerData property. For example:

Swift
Objective-C

let userInfo = Auth.auth().currentUser?.providerData[indexPath.row]
cell?.textLabel?.text = userInfo?.providerID
// Provider-specific UID
cell?.detailTextLabel?.text = userInfo?.uid
Update a user's profile
You can update a user's basic profile information—the user's display name and profile photo URL—with the UserProfileChangeRequest class. For example:

Swift
Objective-C

let changeRequest = Auth.auth().currentUser?.createProfileChangeRequest()
changeRequest?.displayName = displayName
changeRequest?.commitChanges { error in
  // ...
}

When a new user signs up using your app's sign-up form, complete any new account validation steps that your app requires, such as verifying that the new account's password was correctly typed and meets your complexity requirements.
Create a new account by passing the new user's email address and password to createUser.
Swift
Objective-C

Auth.auth().createUser(withEmail: email, password: password) { authResult, error in
  // ...
}
When a user signs in to your app, pass the user's email address and password to signIn.
Swift
Objective-C

Auth.auth().signIn(withEmail: email, password: password) { [weak self] authResult, error in
  guard let strongSelf = self else { return }
  // ...
}
If the user successfully signs in, you can get the user's account data from the result object that's passed to the callback method.


here I upload my current files for you 
Frontend:
orbitalApp.swift 
AppDelegate.swift
MainMapView.swift
SignInViewController.swift
SignInView.swift
FirebaseStorage.swift
LandingView.swift

Baackend:
server.js
authRoutes.js

please modify these files to implement a working version of:

1. when built, show landing view(portrait)
   a title and a logo(image placeholder) vertically aligned, with two buttons "Sign In" and "Sign Up" vertically aligned
2. when Sign Up clicked, direct to firebase authentication Ui service, with email sign up, google sign up and apple sign up enabled. and after successfully signing up, store user email, display name and password in users collection, with document id  generated by firebase
3. after sign up successfully, a line of green text " successfully signed up! please go back to log in" and after click back on the top, redirect to the landing page.
4. after clicking on the sign in button, navigate in to a sign in view:
   a title "welcom to NUSspirit"
   two text boxes one email one password (eye icon on the right to show/hide passwords)
   using the data stored in firestore to verify user(password authentication)
5. after successfully signing in, remain on this page for one second showing a green text: "log in successfully" and navigate to MainMapView
6. on the Sign In page, include a forgot password button and then refer to reset password to include this feature
7. On the MainMapView, SettingsOverlay should be globally shown. and after clicking on the setting icon, a sign out icon appears and setting icon toggles.
8. after clicking on the setting icon again, sign out button disappears immediately and user sign out, navigating back to landing page. 