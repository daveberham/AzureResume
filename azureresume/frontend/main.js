window.addEventListener('DOMContentLoaded',(Event)=>{
    getVisitCount();
})

const functionApi = '' ;
    
const getVisitCount = () => {
    let count = 30;
    fetch(functionApi).then(Response => {
        return Response.json()
    }).then(Response =>{
console.log("website called function API.");
count = Response.count;
document.getElementById("counter").innerText = count;
 }).catch(function(error){
        console.log(error);
 });
 return count;
}