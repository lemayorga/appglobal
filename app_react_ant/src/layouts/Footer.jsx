import React from 'react';

export default function Footer(){
    return(
    <footer className="footer">
        <div className="container-fluid">
            <nav className="pull-left">
                <ul className="nav">
                    <li className="nav-item">
                        <a className="nav-link">
                            ThemeKita
                        </a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link">
                            Help
                        </a>
                    </li>
                    <li className="nav-item">
                        <a className="nav-link">
                            Licenses
                        </a>
                    </li>
                </ul>
            </nav>
            <div className="copyright ml-auto">
                2018, made with <i className="fa fa-heart heart text-danger"></i> by <a>ThemeKita</a>
            </div>				
        </div>
    </footer>
    );
}