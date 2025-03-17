let firstelement = document.querySelector("span");
let word= firstelement.nextSibling;
while(word.nextSibling.nodeType!=3 ){
   word=word.nextSibling;
}
let elzero=word.nextSibling.textContent;
console.log(elzero.trim());