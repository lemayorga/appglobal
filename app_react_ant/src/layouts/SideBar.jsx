import React from 'react'; 
import MainMenu from './menu/MainMenu';

import { Scrollbars } from 'react-custom-scrollbars';

export default function SideBar(){


function OnHoverSideBar(esHover){

	const wrapper = document.getElementsByClassName("wrapper")[0]; 

	if(wrapper != undefined){
		if(esHover){
			if(wrapper.classList.contains('sidebar_minimize'))
				wrapper.classList.add('sidebar_minimize_hover');
		}else{
			if(wrapper.classList.contains('sidebar_minimize'))
				wrapper.classList.remove('sidebar_minimize_hover');
		}
	}
}


    return(
		<div className="sidebar sidebar-style-2"
		onMouseEnter={() => OnHoverSideBar(true)}
        onMouseLeave={() => OnHoverSideBar(false)}
		>	
				{/* <div className="sidebar sidebar-style-2">	
			<div className="sidebar-wrapper scrollbar scrollbar-inner"> */}

			<div className="sidebar-wrapper" style={{ overflowY : 'hidden' }}>
				  
			  <Scrollbars   style={{ height: 'calc(100vh - 75px)' }} autoHide={true}>
				<div className="sidebar-content">
					<div className="user">
						<div className="avatar-sm float-left mr-2">
							<img src="./assets/img/profile.jpg" alt="..." className="avatar-img rounded-circle" />
						</div>
						<div className="info">
							<a data-toggle="collapse" href="#collapseExample" aria-expanded="true">
								<span>
									Hizrian
									<span className="user-level">Administrator</span>
									<span className="caret"></span>
								</span>
							</a>
							<div className="clearfix"></div>

							<div className="collapse in" id="collapseExample">
								<ul className="nav">
									<li>
										<a href="#profile">
											<span className="link-collapse">My Profile</span>
										</a>
									</li>
									<li>
										<a href="#edit">
											<span className="link-collapse">Edit Profile</span>
										</a>
									</li>
									<li>
										<a href="#settings">
											<span className="link-collapse">Settings</span>
										</a>
									</li>
								</ul>
							</div>
						</div>
					</div>
					<MainMenu />
				</div>

			  </Scrollbars>
			</div>
			{/* </div> */}
		</div>

    );
}