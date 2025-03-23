let date1 = "25/10/1982";
let date2 = "25 - 10 - 1982";
let date3 = "25 10 1982";
let date4 = "25 10 82";

let re = /\d{2}(\/| \- | )\d{2}(\/| \- | )(\d{4}|\d{2})/

console.log(date1.match(re)); 
console.log(date2.match(re)); 
console.log(date3.match(re)); 
console.log(date4.match(re));