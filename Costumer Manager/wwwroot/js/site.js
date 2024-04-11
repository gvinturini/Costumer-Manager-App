// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function deleteItem(event) {
    console.log("Click event...")
    const id = event.target.getAttribute("id")
    const token = event.target.getAttribute("data_token")

    fetch("/Customer/Delete" + id, {
        method: "DELETE",
        headers: {
            RequestVerificationToken: token
        }
    }).then(response => response.json())
        .then(val => console.log(val))
        .catch(er => console.log(er))
}