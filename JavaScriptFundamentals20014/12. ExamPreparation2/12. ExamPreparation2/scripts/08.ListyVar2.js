function Solve(array) {
	//var array = [
	//		'def maxy max[100, 5000, 4,2,1]',
	//		'def    summary1  [ 0]',
	//		'def summary11 avg[summary1,maxy]',
	//		'def summary111 avg[   summary11 ,  maxy]',
	//		'def summary1111 avg[summary111 , maxy]',
	//		'sum[75468, summary1111]'
	//];

	var functions = [];
	var numbers = '';

	for (var i = 0; i < array.length; i++) {
		numbers = array[i].substring(array[i].indexOf('[') + 1, array[i].lastIndexOf(']'));
		array[i] = array[i].split(/[,[\]\s\r\n^ ]+/g);
		if (array[i].indexOf('sum') == -1 &&
			array[i].indexOf('min') == -1 &&
			array[i].indexOf('max') == -1 &&
			array[i].indexOf('avg') == -1) {

			functions.push({ fName: array[i][1], operation: 'none', value: numbers });
		}
		else {
			functions.push({ fName: array[i][1], operation: array[i][2], value: numbers });
		}
	}

	for (var i = 0; i < functions.length; i++) {
		var operator = functions[i].operation;

		if (i == functions.length - 1) {
			operator = array[i][0];
			functions[i].operation = array[i][0];
			functions[i].value = functions[i].value.split(/[,[\]\s\r\n^ ]+/g);
			functions[i].fName = 'result';
			return finalResult(operator, functions[i]);
		}

		functions[i].value = functions[i].value.split(/[,[\]\s\r\n^ ]+/g);

		switch (operator) {
			case 'sum': sum(functions[i]); break;
			case 'min': min(functions[i]); break;
			case 'max': max(functions[i]); break;
			case 'avg': avg(functions[i]); break;
			default:
		}
	}

	function max(func) {
		for (var i = 0; i < func.value.length; i++) {
			if (!isNaN(parseInt(func.value[i]))) {
				func.value[i] = parseInt(func.value[i]);
			}
			else {
				addValue(func, func.value[i], i);
				i -= 1;
			}
		}

		func.value = Math.max.apply(Math, func.value);
		return (func.value);
	}

	function min(func) {
		for (var i = 0; i < func.value.length; i++) {
			if (!isNaN(parseInt(func.value[i]))) {
				func.value[i] = parseInt(func.value[i]);
			}
			else {
				addValue(func, func.value[i], i);
				i -= 1;
			}
		}

		func.value = Math.min.apply(Math, func.value);
		return (func.value);
	}

	function sum(func) {
		var sumNums = 0;
		for (var i = 0; i < func.value.length; i++) {
			if (!isNaN(parseInt(func.value[i]))) {
				sumNums += parseInt(func.value[i]);
			}
			else {
				addValue(func, func.value[i], i);
				i -= 1;
			}
		}

		func.value = sumNums;
		return (sumNums);
	}

	function avg(func) {
		var len = func.value.length;
		var sumNums = sum(func);
		func.value = Math.floor(sumNums / len);
		return (func.value);
	}


	function addValue(func, currentValue, index) {
		func.value.splice(index, 1);
		for (var i = 0; i < functions.length; i++) {
			if (functions[i].fName == currentValue) {
				if (!isNaN(functions[i].value)) {
					func.value.push(functions[i].value);
					break;
				}
				else {
					for (var j = 0; j < functions[i].value.length; j++) {
						if (functions[i].value[j] != '') {
							func.value.push(functions[i].value[j]);
						}

					}
					break;
				}
			}
		}
	}

	function finalResult(operator, func) {

		switch (operator) {
			case 'sum': return sum(func); break;
			case 'avg': return avg(func); break;
			case 'min': return min(func); break;
			case 'max': return max(func); break;
			default:
				for (var i = 0; i < functions.length; i++) {
					if (functions[i].fName == func.value) {
						return (functions[i].value);
					}
				}
		}
	}

	//console.log(array[1]);
}