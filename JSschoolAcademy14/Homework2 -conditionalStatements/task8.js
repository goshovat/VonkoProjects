function checkNum() {
	var number = document.getElementById("digit").value;
	var num = number.toString();
	if (num.length ===1) {

		switch(num) {
		case "0": jsConsole.writeLine("Zero"); break;
		case "1": jsConsole.writeLine("One"); break;
        case "2": jsConsole.writeLine("Two"); break;
        case "3": jsConsole.writeLine("Three"); break;
        case "4": jsConsole.writeLine("Four"); break;
        case "5": jsConsole.writeLine("Five"); break;
        case "6": jsConsole.writeLine("Six"); break;
        case "7": jsConsole.writeLine("Seven"); break;
        case "8": jsConsole.writeLine("Eight"); break;
        case "9": jsConsole.writeLine("Nine"); break;
        default:
		}
	}

	if (num.length === 2) {

		if (num[0] != 1) {

			switch(num[0]) {
			case "2": jsConsole.writeLine("Twenty "); break;
            case "3": jsConsole.writeLine("Thirty "); break;
            case "4": jsConsole.writeLine("Fourty "); break;
            case "5": jsConsole.writeLine("Fifty "); break;
            case "6": jsConsole.writeLine("Sixty "); break;
            case "7": jsConsole.writeLine("Seventy "); break;
            case "8": jsConsole.writeLine("Eighty "); break;
            case "9": jsConsole.writeLine("Ninety "); break;
            default:
			}
			switch(num[1]) {
			case "1": jsConsole.writeLine("One"); break;
            case "2": jsConsole.writeLine("Two"); break;
            case "3": jsConsole.writeLine("Three"); break;
            case "4": jsConsole.writeLine("Four"); break;
            case "5": jsConsole.writeLine("Five"); break;
            case "6": jsConsole.writeLine("Six"); break;
            case "7": jsConsole.writeLine("Seven"); break;
            case "8": jsConsole.writeLine("Eight"); break;
            case "9": jsConsole.writeLine("Nine"); break;
            default:
			}
		}
		else {
			switch (num[1]) {
			case "0": jsConsole.writeLine("Ten"); break;
            case "1": jsConsole.writeLine("Eleven"); break;
            case "2": jsConsole.writeLine("Twelve"); break;
            case "3": jsConsole.writeLine("Thirteen"); break;
            case "4": jsConsole.writeLine("Fourteen"); break;
            case "5": jsConsole.writeLine("Fifteen"); break;
            case "6": jsConsole.writeLine("Sixteen"); break;
            case "7": jsConsole.writeLine("Seventeen"); break;
            case "8": jsConsole.writeLine("Eighteen"); break;
            case "9": jsConsole.writeLine("Nineteen"); break;
            default:
			}
		}
	}

	if (num.length === 3) {
		
	    switch (num[0]) {	    
	        case "1": jsConsole.writeLine("One hundred "); break;
	        case "2": jsConsole.writeLine("Two hundred "); break;
	        case "3": jsConsole.writeLine("Three hundred "); break;
	        case "4": jsConsole.writeLine("Four hundred "); break;
	        case "5": jsConsole.writeLine("Five hundred "); break;
	        case "6": jsConsole.writeLine("Six hundred "); break;
	        case "7": jsConsole.writeLine("Seven hundred "); break;
	        case "8": jsConsole.writeLine("Eight hundred "); break;
	        case "9": jsConsole.writeLine("Nine hundred "); break;
	        default:
	    	}

	    if (num[1] == 0) {
	    
	        switch (num[2])
	        {
	            case "1": jsConsole.writeLine("and one"); break;
	            case "2": jsConsole.writeLine("and two"); break;
	            case "3": jsConsole.writeLine("and three"); break;
	            case "4": jsConsole.writeLine("and four"); break;
	            case "5": jsConsole.writeLine("and five"); break;
	            case "6": jsConsole.writeLine("and six"); break;
	            case "7": jsConsole.writeLine("and seven"); break;
	            case "8": jsConsole.writeLine("and eight"); break;
	            case "9": jsConsole.writeLine("and nine"); break;
	            default:
	        }
	    }

	    if (num[1] == 1)	{
	    
	        switch (num[2])
	        {
	            case "0": jsConsole.writeLine("and ten"); break;
	            case "1": jsConsole.writeLine("and eleven"); break;
	            case "2": jsConsole.writeLine("and twelve"); break;
	            case "3": jsConsole.writeLine("and thirteen"); break;
	            case "4": jsConsole.writeLine("and fourteen"); break;
	            case "5": jsConsole.writeLine("and fifteen"); break;
	            case "6": jsConsole.writeLine("and sixteen"); break;
	            case "7": jsConsole.writeLine("and seventeen"); break;
	            case "8": jsConsole.writeLine("and eighteen"); break;
	            case "9": jsConsole.writeLine("and nineteen"); break;
	            default:
	        }
	    }

	    if (num[1] != 0 && num[1] != 1) {
	    
	        switch (num[1])
	        {
	            case "2": jsConsole.writeLine("and twenty "); break;
	            case "3": jsConsole.writeLine("and thirty "); break;
	            case "4": jsConsole.writeLine("and fourty "); break;
	            case "5": jsConsole.writeLine("and fifty "); break;
	            case "6": jsConsole.writeLine("and sixty "); break;
	            case "7": jsConsole.writeLine("and seventy "); break;
	            case "8": jsConsole.writeLine("and eighty "); break;
	            case "9": jsConsole.writeLine("and ninety "); break;
	            default:
	        }
	        switch (num[2])
	        {
	            case "1": jsConsole.writeLine("one"); break;
	            case "2": jsConsole.writeLine("two"); break;
	            case "3": jsConsole.writeLine("three"); break;
	            case "4": jsConsole.writeLine("four"); break;
	            case "5": jsConsole.writeLine("five"); break;
	            case "6": jsConsole.writeLine("six"); break;
	            case "7": jsConsole.writeLine("seven"); break;
	            case "8": jsConsole.writeLine("eight"); break;
	            case "9": jsConsole.writeLine("nine"); break;
	            default:
	        }
	    }
		
	}
}

