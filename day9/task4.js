let arr1 = ["Ahmed", "Sameh", "Sayed"];
let arr2 = ["Mohamed", "Gamal", "Amir"];
let arr3 = ["Haytham", "Shady", "Mahmoud"];

let obj={};
let arrays={arr1,arr3};
Object.assign(obj,arrays);

const{arr1:[c],arr3:[,a,b]}=obj;
console.log(`My Best Friends: ${a}, ${b}, ${c}`);
// My Best Friends: Shady, Mahmoud, Ahmed