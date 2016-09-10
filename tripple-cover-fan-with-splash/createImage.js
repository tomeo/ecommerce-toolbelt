var element = document.createElement('div');
var att = document.createAttribute("id");
att.value = "hide";
element.setAttributeNode(att);
element.innerHTML = document.getElementById('outer').innerHTML;
document.body.appendChild(element);
html2canvas(element, {
onrendered: function(canvas) {
  document.body.appendChild(canvas);
},
  width: 240,
  height: 240,
  logging: true
});
document.getElementById('outer').style.display = 'none';
document.getElementById('hide').style.display = 'none';
