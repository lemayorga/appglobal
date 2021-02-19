import { Slider } from 'antd';
import React,{ useState } from 'react';


export default function CustomTheme(){
	const [custom_open, setCustom_open] = useState(0);
  
	function OnClickCustomToggle(){
		const custom_toggle = document.querySelector(".custom-template > .custom-toggle"); 
		const custom_template = document.getElementsByClassName("custom-template")[0]; 

		if(custom_template != undefined && custom_toggle != undefined){
			if (custom_open == 1){
				custom_template.classList.remove('open');
				custom_toggle.classList.remove('toggled');
				setCustom_open(0);

			}  else {
				custom_template.classList.add('open');
				custom_toggle.classList.add('toggled');
				setCustom_open(1);

			}	
		}
	}

	function layoutsColors(){
		const html = document.querySelector("html");
		const body = document.querySelector("html");
		const sidebar = document.querySelector(".sidebar");

		if(sidebar != undefined){
			if(sidebar.hasAttribute('data-background-color')){
				html.classList.add('sidebar-color');
			} else{
				html.classList.remove('sidebar-color');
			}
		}
	}
	

	function changeTopBarColor(e) {
		const navbar_header = document.querySelector('.main-header .navbar-header')
		if(e.target.getAttribute('data-color') == 'default'){
			navbar_header.removeAttribute('data-background-color')
		}else{
			const data_color = e.target.getAttribute('data-color');
			navbar_header.setAttribute('data-background-color',data_color);
		}
		 const childrens  = e.target.parentNode.childNodes;
		 for (var i = 0; i < childrens.length; i++) {
			var inner = childrens[i];
			if (inner.className == 'selected') {
				inner.classList.remove('selected');
			}
		}

		e.target.classList.add('selected')
		layoutsColors();
	}


	function changeLogoHeaderColor(e){
		const logo_header = document.querySelector('.logo-header');

		if(e.target.getAttribute('data-color') == 'default'){
			logo_header.removeAttribute('data-background-color');
		}else{
			logo_header.setAttribute('data-background-color',e.target.getAttribute('data-color'));
		}

		const childrens  = e.target.parentNode.childNodes;
		for (var i = 0; i < childrens.length; i++) {
		   var inner = childrens[i];
		   if (inner.className == 'changeLogoHeaderColor') {
			   inner.classList.remove('selected');
		   }
	    }

		e.target.classList.add('selected')
		customCheckColor();
		layoutsColors();
	}

	function customCheckColor(){
		const logo_header = document.querySelector('.logo-header');
		const navbar_brand = document.querySelector('.logo-header .navbar-brand');

		if (logo_header.getAttribute('data-background-color') !== "white") {
			navbar_brand.setAttribute('src', '../assets/img/logo.svg');
		} else {
			navbar_brand.setAttribute('src', '../assets/img/logo2.svg');
		}
	}

	function changeSideBarColor(e){
		const sidebar = document.querySelector('.sidebar');

		if(e.target.getAttribute('data-color') == 'default'){
			sidebar.removeAttribute('data-background-color');
		}else{
			sidebar.setAttribute('data-background-color',e.target.getAttribute('data-color'));
		}

		const childrens  = e.target.parentNode.childNodes;
		for (var i = 0; i < childrens.length; i++) {
		   var inner = childrens[i];
		   if (inner.className == 'changeSideBarColor') {
			   inner.classList.remove('selected');
		   }
	    }

		e.target.classList.add('selected')
		layoutsColors();
	}

	function changeBackgroundColor(e){
		const body = document.querySelector("body");
		body.removeAttribute('data-background-color');
		body.setAttribute('data-background-color',e.target.getAttribute('data-color'));
		
		const childrens  = e.target.parentNode.childNodes;
		for (var i = 0; i < childrens.length; i++) {
		   var inner = childrens[i];
		   if (inner.className == 'changeBackgroundColor') {
			   inner.classList.remove('selected');
		   }
	   }

	   e.target.classList.add('selected')

	}

	return(
		<div className="custom-template"> 
			<div className="title">Settings</div>
			<div className="custom-content">
				<div className="switcher">
					<div className="switch-block">
						<h4>Logo Header</h4>
						<div className="btnSwitch">
							<button type="button" className="changeLogoHeaderColor" data-color="dark" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="selected changeLogoHeaderColor" data-color="blue" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="purple" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="light-blue" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="green" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="orange" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="red" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="white" onClick={changeLogoHeaderColor}></button>
							<br/>
							<button type="button" className="changeLogoHeaderColor" data-color="dark2" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="blue2" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="purple2" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="light-blue2" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="green2" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="orange2" onClick={changeLogoHeaderColor}></button>
							<button type="button" className="changeLogoHeaderColor" data-color="red2" onClick={changeLogoHeaderColor}></button>
						</div>
					</div>
					<div className="switch-block">
						<h4>Navbar Header</h4>
						<div className="btnSwitch">
							<button type="button" className="changeTopBarColor" data-color="dark" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="blue" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="purple" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="light-blue" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="green" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="orange" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="red" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="white" onClick={changeTopBarColor}></button>
							<br/>
							<button type="button" className="changeTopBarColor" data-color="dark2" onClick={changeTopBarColor}></button>
							<button type="button" className="selected changeTopBarColor" data-color="blue2" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="purple2" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="light-blue2" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="green2" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="orange2" onClick={changeTopBarColor}></button>
							<button type="button" className="changeTopBarColor" data-color="red2" onClick={changeTopBarColor}></button>
						</div>
					</div>
					<div className="switch-block">
						<h4>Sidebar</h4>
						<div className="btnSwitch">
							<button type="button" className="selected changeSideBarColor" data-color="white"  onClick={changeSideBarColor}></button>
							<button type="button" className="changeSideBarColor" data-color="dark" onClick={changeSideBarColor}></button>
							<button type="button" className="changeSideBarColor" data-color="dark2" onClick={changeSideBarColor}></button>
						</div>
					</div>
					<div className="switch-block">
						<h4>Background</h4>
						<div className="btnSwitch">
							<button type="button" className="changeBackgroundColor" data-color="bg2" onClick={changeBackgroundColor}></button>
							<button type="button" className="changeBackgroundColor selected" data-color="bg1" onClick={changeBackgroundColor}></button>
							<button type="button" className="changeBackgroundColor" data-color="bg3" onClick={changeBackgroundColor}></button>
							<button type="button" className="changeBackgroundColor" data-color="dark" onClick={changeBackgroundColor}></button>
						</div>
					</div>
				</div>
			</div>
			<div className="custom-toggle"   onClick={OnClickCustomToggle}>
				<i className="flaticon-settings"></i>
			</div>
        </div>
    );
}