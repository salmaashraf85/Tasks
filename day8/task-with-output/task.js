let input_num=document.querySelector('#number');
let input_txt=document.querySelector('#Text');
let input_button=document.querySelector('#button');
let output=document.querySelector('.output');

input_button.addEventListener("click",function(){
    output.innerHTML="";
    for(let i =0;i<input_num.value;i++){
        let box=document.createElement("div");
        box.classList.add("box");
        box.textContent=input_txt.value;
        output.appendChild(box);
    }
})


