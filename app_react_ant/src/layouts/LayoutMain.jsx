import React from 'react';

// // import * as $ from 'jquery';
// import '../assets/js/atlantis.js';
// import '../assets/js/setting_demo.js';

import Footer from '../layouts/Footer';
import Header from '../layouts/Header';
import SideBar from '../layouts/SideBar';
import CustomTheme from '../layouts/CustomTheme';

const LayoutMain = ({ children }) =>{
	return(
		<div className="wrapper">
			<Header />
			<SideBar />
			<div className="main-panel">
				<div className="content">
					<div className="page-inner">
						{children}
					</div>		
				</div>
				<Footer />
			</div>
			<CustomTheme />
		</div>
	)
}

export default LayoutMain;