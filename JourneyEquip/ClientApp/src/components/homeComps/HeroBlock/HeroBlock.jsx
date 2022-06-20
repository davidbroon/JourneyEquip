import './HeroBlock.Style.css';
import { accent3, accent2 } from '../../../style/colorConstants';
import { GlobalContext } from '../../../context/GlobalContext';
import { useContext, useEffect, useState } from 'react';
import WaitListForm from '../WaitListFormFolder/WaitForm';

const HeroBlock = () => {
	const [formOpen] = useContext(GlobalContext);
	const [lineDisplay, setLineDisplay] = useState('visible');

	useEffect(() => {
		formOpen ? setLineDisplay('hidden') : setLineDisplay('visible');
	}, [formOpen]);
	const pStyles = formOpen ? { height: '14vh', fontSize: '80%' } : {};
	return (
		<div className='heroImage'>
			<div className='heroContainer'>
				<div className='heroTextContainer'>
					<p style={pStyles} className='heroTitleText'>
						Equipping Leaders for revival
					</p>
				</div>

				<div className='heroButtonAndLine'>
					<WaitListForm />
					<div
						className='heroLine'
						style={{ background: accent3, visibility: lineDisplay }}
					/>
				</div>
			</div>
		</div>
	);
};
export default HeroBlock;
