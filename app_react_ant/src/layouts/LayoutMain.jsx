import React from 'react';

// // import * as $ from 'jquery';
// import '../assets/js/atlantis.js';
// import '../assets/js/setting_demo.js';

import Footer from './Footer';
import Header from './Header';
import SideBar from './SideBar';
import CustomTheme from './CustomTheme';

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