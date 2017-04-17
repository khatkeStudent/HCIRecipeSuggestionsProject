function adjustWeekSize() {
	var weekview = document.getElementById("divWeekview")
	var days = document.getElementsByClassName("weekviewday");
	var daynames = document.getElementsByClassName("weekviewdayname");
	var pagewidth = document.body.clientWidth;
	var w = (weekview.offsetWidth / 7);
	
	for (var i=0; i<days.length; i++) {
		days[i].style.width= w;
	}
	
	if (w < 95) {
		for (var i=0;i<daynames.length;i++) {
			if (daynames[i].innerHTML == "Sunday") {
				daynames[i].innerHTML = "Sun";
			} else if (daynames[i].innerHTML == "Monday") {
				daynames[i].innerHTML = "Mon";
			} else if (daynames[i].innerHTML == "Tuesday") {
				daynames[i].innerHTML = "Tues";
			} else if (daynames[i].innerHTML == "Wednesday") {
				daynames[i].innerHTML = "Wed";
			} else if (daynames[i].innerHTML == "Thursday") {
				daynames[i].innerHTML = "Thur";
			} else if (daynames[i].innerHTML == "Friday") {
				daynames[i].innerHTML = "Fri";
			} else if (daynames[i].innerHTML == "Saturday") {
				daynames[i].innerHTML = "Sat";
			}
		}
	} else {
		for (var i=0;i<daynames.length;i++) {
			if (daynames[i].innerHTML == "Sun") {
				daynames[i].innerHTML = "Sunday";
			} else if (daynames[i].innerHTML == "Mon") {
				daynames[i].innerHTML = "Monday";
			} else if (daynames[i].innerHTML == "Tues") {
				daynames[i].innerHTML = "Tuesday";
			} else if (daynames[i].innerHTML == "Wed") {
				daynames[i].innerHTML = "Wednesday";
			} else if (daynames[i].innerHTML == "Thur") {
				daynames[i].innerHTML = "Thursday";
			} else if (daynames[i].innerHTML == "Fri") {
				daynames[i].innerHTML = "Friday";
			} else if (daynames[i].innerHTML == "Sat") {
				daynames[i].innerHTML = "Saturday";
			}
		}
	}
}