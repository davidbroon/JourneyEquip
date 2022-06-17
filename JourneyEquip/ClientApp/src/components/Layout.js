import React, { Component } from 'react';
import { Container } from 'reactstrap';
import { NavMenu } from './NavMenu';
import { GlobalContextProvider } from '../context/GlobalContext';
import Header from './Header/Header';
import Footer from './Footer/Footer';

export class Layout extends Component {
	static displayName = Layout.name;

	render() {
		return (
			<div>
				<GlobalContextProvider>
					<Header />
					<div className='appContainer'>{this.props.children}</div>
					<Footer />
				</GlobalContextProvider>
			</div>
		);
	}
}
