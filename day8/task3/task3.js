const x=document.querySelectorAll('img');

for(const i of x){
   i.alt= i.hasAttribute('alt') ? 'Old':'Elzero New';
}