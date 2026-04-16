import React from 'react';
import { Route } from 'react-router-dom';
import { LocalAreasPage } from '../localAreasPage';
import { LocalAreaLink } from './localAreaLink';

export function LocalAreasRouter() {
	return (
		<>
			<Route path={LocalAreaLink.index} element={<LocalAreasPage/>} />
		</>
	);
}
