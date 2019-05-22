var currentList = {};

function createShoppingList() {
    //sets list name to input at top of page
    currentList.name = $("#shoppingListName").val();
    currentList.items = new Array();

    //web service call
    showShoppingList();
}

function showShoppingList() {
    //changes view2's title to the name of list
    $("#shoppingListTitle").html(currentList.name);
    //clears the list of items from default to empty
    $("#shoppingListItems").empty();
    //hide view1 and display view2
    $("#createListDiv").hide();
    $("#shoppingListDiv").show();

    $("#newItemName").focus();
    $("#newItemName").keyup(function (event) {
        //checks to see if enter is pressed
        if (event.keyCode == 13) {
            addItem();
        }
    });
}
//adds items to the list
function addItem() {
    //create item array, tow ways of constructing
    var newItem = {name: $("#newItemName").val()};
    //newItem.name = $("#newItemName").val();
    currentList.items.push(newItem);
    //test
    console.info(currentList);
    drawItems();
    $("#newItemName").val("");
}
//seperate function in case we want to call the function by id in the url instead of on click
function drawItems() {
    //create list object and clear out any possible leftover items from previous calls
    var $list = $("#shoppingListItems").empty();//<ul>

    for (var i = 0; i < currentList.items.length; i++) {
        var currentItem = currentList.items[i];
        //construct list item
        var $li = $("<li>").html(currentItem.name).attr("id", "item_" + i);
        //note: alternate quote types when nesting things that need quotes
        var $deleteBtn = $("<button onclick='deleteItem(" + i + ")'>D</button>").appendTo($li);

        var $checkBtn = $("<button onclick='checkItem(" + i + ")'>C</button>").appendTo($li);
        //add list item to the list
        $li.appendTo($list);
    }

}

function deleteItem(index) {
    currentList.items.splice(index, 1);
    //call again to display new list with deletion
    drawItems();
}

function checkItem(index) {
    if ($("#item_" + index).hasClass("checked")) {
        $("#item_" + index).removeClass("checked");
    }
    else
    {
        $("#item_" + index).addClass("checked");
    }
    
}



function getShoppingListById(id) {
    console.info(id);
    //no webserver to create a dummby
    currentList.name = "Dummy List";
    currentList.items = [{ name: "Apple" }, { name: "Bread" }, { name: "Milk" }];

    showShoppingList();
    drawItems();
}

$(document).ready(function () {
    console.log("ready");
    $("#shoppingListName").focus();
    $("#shoppingListName").keyup(function (event) {
        //checks to see if enter is pressed
        if (event.keyCode == 13) {
            createShoppingList();
        }
    });

    var pageURL = window.location.href;
    var idIndex = pageURL.indexOf("?id=");
    //checks if it is not at the end and therefore there must be a number after it
    if (idIndex != -1) {
        //add 4 1 for each char in above substring
        getShoppingListById(pageURL.substring(idIndex + 4));
    }
});

