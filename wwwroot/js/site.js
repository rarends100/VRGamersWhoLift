// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const ProfilePhotoChooser = document.querySelector("#profile_photo_chooser");
const profilePhoto = document.querySelector("#profile_photo");





//Functions ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//Toggles (Hides or unhides) an element on the page.

const toggleElementHidden= (clickElem, TohideUnhideElem) => {
    clickElem.addEventListener("click", () => {
        if (TohideUnhideElem.classList.contains("hidden")) {
            TohideUnhideElem.classList.remove("hidden");
        } else if (!TohideUnhideElem.classList.contains("hidden")) {
            TohideUnhideElem.classList.add("hidden");
        }
    });
}


//Functions in use--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//toggles profile photo choice partial view hidden/unhidden if the profile photo is clicked
if (profilePhoto != null) {
    toggleElementHidden(profilePhoto, ProfilePhotoChooser);
}




