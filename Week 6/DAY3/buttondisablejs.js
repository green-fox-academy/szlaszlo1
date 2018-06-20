function enableButton()
{
if(document.getElementById("cat").checked==1 || document.getElementById("dog").checked==1)
{
document.getElementById("signup").disabled=false;
document.getElementById("signup").style.background='#000000';
}
else
{
document.getElementById("signup").disabled=true;
document.getElementById("signup").style.background='#a6a6a6';
if(document.getElementById("no").checked==1)
{
document.getElementById("signup").disabled=false;
document.getElementById("signup").style.background='#000000';
}
}

if(document.getElementById("yes").checked==1)
{
document.getElementById("lovecat").disabled=false;
document.getElementById("lovecat").style.background='#000000';
}
else
{
document.getElementById("lovecat").disabled=true;
document.getElementById("lovecat").style.background='#a6a6a6';
if(document.getElementById("fish").checked==1)
{
document.getElementById("signup").disabled=false;
document.getElementById("signup").style.background='#000000';
}
}
}

function nyominger()
{
if(document.getElementById("fish").checked==1 && document.getElementById("no").checked==1){

alert("Sigh, we still added you to the cat facts list");
}
else{
	
alert("Thank you, you've successfully signed up for cat facts");	
}
}