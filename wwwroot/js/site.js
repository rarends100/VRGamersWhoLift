"use strict";

// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const profilePhotoChooser = document.querySelector("#profile_photo_chooser");
const profilePhoto = document.querySelector("#profile_photo");


const profileBannerChooser = document.querySelector("#profile_banner_chooser");
const profileBanner = document.querySelector("#profile_banner");

const newPostToggle = document.querySelector("#new_post_button_toggle");
const newPost = document.querySelector("#new_post");

//parrallell edit posts element node lists
const editPostClickNodeList = document.querySelectorAll("#toggle_post_edit_form_button");
const exitEditPostclickNodeList = document.querySelectorAll("#exit_edit_post_button");
const editPostFormDisplayNodeList = document.querySelectorAll("#edit_post");

//Function Definitions ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//Toggles (Hides or unhides) an element on the page.

const toggleSectionHidden= (clickElem, TohideUnhideOrHideElem) => {
    clickElem.addEventListener("click", () => {
        if (TohideUnhideOrHideElem.classList.contains("hidden")) {
            TohideUnhideOrHideElem.classList.remove("hidden");
        } else if (!TohideUnhideOrHideElem.classList.contains("hidden")) {
            TohideUnhideOrHideElem.classList.add("hidden");
        }
    });
}

//Toggle functions for 2 step, 2 button click necessity cases
const toggleSectionOff = (clickElem, toHideElem) => {
    clickElem.addEventListener("click", () => {
        if (!toHideElem.classList.contains("hidden")) {
            toHideElem.classList.add("hidden");
        }
    });
}

const toggleSectionOn = (clickElem, toUnHideElem) => {
    clickElem.addEventListener("click", () => {
        if (toUnHideElem.classList.contains("hidden")) {
            toUnHideElem.classList.remove("hidden");
        }
    });
}

//Functions in use--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

//toggles profile photo choice partial view hidden/unhidden if the profile photo is clicked
if (profilePhoto != null) {
    toggleSectionHidden(profilePhoto, profilePhotoChooser);
}

//toggles profile banner choice partial view hidden/unhidden if the profile photo is clicked
if (profileBanner != null) {
    toggleSectionHidden(profileBanner, profileBannerChooser);
}

//toggle add post
if (newPostToggle != null && newPost != null) {
    toggleSectionHidden(newPostToggle, newPost);
}

//toggle edit post
if (editPostClickNodeList != null && editPostFormDisplayNodeList != null) {
    let index = 0; //ensures appropiate posts associated form is accessed, so that the correct post is edited
    editPostClickNodeList.forEach(elem => { //https://stackoverflow.com/questions/56990500/javascript-iterate-through-nodelist
        console.log("element is " + elem);
        toggleSectionOn(elem, editPostFormDisplayNodeList.item(index));
        editPostFormDisplayNodeList.item(index).scrollIntoView(); //https://stackoverflow.com/questions/24739126/scroll-to-a-specific-element-using-html
        index++;
    }); 
    
}
if (exitEditPostclickNodeList != null && editPostFormDisplayNodeList != null) {
    let index = 0; //ensures the correct form is closed
    exitEditPostclickNodeList.forEach(elem => {
        toggleSectionOff(elem, editPostFormDisplayNodeList.item(index));
        index++;
    });
}


