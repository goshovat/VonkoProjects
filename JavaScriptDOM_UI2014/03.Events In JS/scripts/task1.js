function renderElements() {

    //first we create the elements
    var dFrag = document.createDocumentFragment();

    var divCondition = document.createElement('div');
    divCondition.id = 'condition';
    divCondition.innerHTML = 'You can add new tasks to the list, you can select and remove tasks, you can select a task and hide it or you can press "Show" to reveal all hddden tasks:';
    dFrag.appendChild(divCondition);

    var labelObj = document.createElement('label');
    labelObj.
    for = 'input';
    labelObj.innerHTML = 'Write the task to be added here: ';
    dFrag.appendChild(labelObj);

    var inputObj = document.createElement('input');
    inputObj.type = 'text';
    inputObj.id = 'input';
    inputObj.name = 'input';
    inputObj.value = '';
    dFrag.appendChild(inputObj);

    var ulObj = document.createElement('ul');

    var addButton = document.createElement('button');
    addButton.innerHTML = 'Add';
    dFrag.appendChild(addButton);

    var removeButton = document.createElement('button');
    removeButton.innerHTML = 'Remove';
    dFrag.appendChild(removeButton);

    var showButton = document.createElement('button');
    showButton.innerHTML = 'Show';
    dFrag.appendChild(showButton);

    var hideButton = document.createElement('button');
    hideButton.innerHTML = 'Hide';
    dFrag.appendChild(hideButton);

    dFrag.appendChild(ulObj);

    document.body.appendChild(dFrag);

    removeButton.addEventListener('click', removeItems);
    hideButton.addEventListener('click', hideItems);
    showButton.addEventListener('click', showItems);

    //we define function for adding new items

    function addNewItems() {
        var value = document.getElementsByTagName('input')[0].value;

        if (value != '') {
            var currentLi = document.createElement('li');
            currentLi.innerHTML = value;
            currentLi.setAttribute('data-selected', 'no');

            //atach event to every created li for select and unselect
            currentLi.addEventListener('click', selectUnselectItems);

            ulObj.appendChild(currentLi);
        }
    }

    //we define the function for selecting/unselecting items

    function selectUnselectItems() {
   
        if (this.dataset.selected == 'no') {
            this.setAttribute('data-selected', 'yes');
            this.style.background = '#ffeeee';
        } else if (this.dataset.selected == 'yes') {
            this.setAttribute('data-selected', 'no');
            this.style.background = 'white';
        }
    }

    //we define function for removing all selected items

    function removeItems() {
    	var selectedItems = document.getElementsByTagName('li');

    	for (var i = 0, len = selectedItems.length; i < len; i++) {
    		if (selectedItems[i].dataset.selected == 'yes') {
    			selectedItems[i].parentNode.removeChild(selectedItems[i]);
    			i--;
    		}
    	};
    }

    function hideItems() {
    	var selectedItems = document.getElementsByTagName('li');

    	for (var i = 0, len = selectedItems.length; i < len; i++) {
    		if (selectedItems[i].dataset.selected == 'yes') {
    			selectedItems[i].style.display = 'none';
    			selectedItems[i].dataset.selected = 'no';
    		}
    	};
    }

    function showItems() {
    	var selectedItems = document.getElementsByTagName('li');

    	for (var i = 0, len = selectedItems.length; i < len; i++) {
    		if (selectedItems[i].style.display == 'none') {
    			selectedItems[i].style.display = 'block';
    			selectedItems[i].style.background = 'white';

    			selectedItems[i].addEventListener('mouseover', function() {
    				this.style.background = 'gray';
    			});

    			selectedItems[i].addEventListener('mouseleave', function() {
    				if (this.dataset.selected == 'yes') {
    					this.style.background = '#ffeeee';
    				} else {
    					this.style.background = 'white';
    				}
    			})
    		}
    	};
    }
}

window.onload = function() {
    renderElements();
}
