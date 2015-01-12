document.getElementById("click").onclick = function Print() {
	
	var biggest = Number.MIN_VALUE;
	var smallest = Number.MAX_VALUE;
	var input = document.getElementById('n').value;
	var arr = input.split(' ');

	var i = 0;

		for (; i < arr.length; i++) {
			
			if (isNaN(arr[i]) || arr[i] == null || arr[i] == "" ) {
				alert("Please enter valid string!");
				return;
			}

			if (smallest > parseFloat(arr[i])) {
				smallest = arr[i];
			}
			
				

			if (biggest < parseFloat(arr[i])) {
				biggest = arr[i];
			}
			
			
			}
		
			var output = "The biggest number is " + biggest + "\nThe smallest number is " + smallest;

			document.getElementById("show").innerHTML = output;
		
		}