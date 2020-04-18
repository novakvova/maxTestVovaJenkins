import axios from "axios";

//export async function GetrequestCarList() {
//	const url = `api/Car/GetCars`;
//	let cars;
//	await axios
//		.get(url)
//		.then(response =>
//			cars = response.data);
//	console.log(cars);
//	return { type: "GetCars", carList: cars };
//	//dispatch({ type: "GetCars", carList: cars });
//}
export const actionCreators = {
	GetrequestCarList: nullstartDateIndex => async (dispatch) => {
		const url = `api/Car/GetCars`;
		let cars;
		await axios
			.get(url)
			.then(response =>
				cars = response.data);
		console.log(cars);
		dispatch({ type: "GetCars", cars });
		return;

	}
};