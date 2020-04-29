import React, { Component,Fragment } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from "../../../../store/Actions/CarActions";
import { Lightbox } from 'primereact/lightbox';
import { TabView, TabPanel } from 'primereact/tabview';

class CarPost extends Component {

	state= {
		mainImage: ""
	};
	componentDidMount() {
		this.ensureDataFetched();		
	}
	async	ensureDataFetched() {
		const id = this.props.match.params.id;
		await this.props.GetCarById(id);
		this.setState(({ mainImage }) => {
			return {

				mainImage: this.props.selectCar.image[0]

			};

		});
	}
	render() {
		let { name,price } = this.props.selectCar;
		let { mainImage } = this.state;
		var formatter = new Intl.NumberFormat('en-US', {
			style: 'currency',
			currency: 'USD',
		});
		price = formatter.format(price);
		//if (this.props.selectCar.image) {
		//	Object.entries(this.props.selectCar.image);
		//	console.log((this.props.selectCar.image[0]));
		//	mainImage = image[0];
		//}
		const images = [
			{
				source: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				thumbnail: 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__340.jpg',
				title: 'Sopranos 1'
			},
			{
				source: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				//thumbnail: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				title: 'Sopranos 2'
			},
			{
				source: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				//thumbnail: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				title: 'Sopranos 3'
			},
			{
				source: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				//	thumbnail: 'https://helpx.adobe.com/content/dam/help/en/stock/how-to/visual-reverse-image-search/jcr_content/main-pars/image/visual-reverse-image-search-v2_intro.jpg',
				title: 'Sopranos 4'
			}
		];
		return (

			<Fragment>	
   
				<div className="container">
					
						<div className="row">
						<div class="information_block">
							<div className="col-md-7">
								<img class="image" src={mainImage} />

							</div>
							<div className="col-md-5 informationCar">
								<h2 className="carName">{name}</h2>
								<p class="product-price">{price}</p>

							</div>
							</div>
			

					</div>
					<TabView>
						<TabPanel header="Header I">
							Content I
							
							</TabPanel>
						<TabPanel header="Header II">
							Content II
							
							</TabPanel>
						<TabPanel header="Header III">
							Content III
							
							</TabPanel>
					</TabView>
				</div>
			</Fragment>
				
				
			//<div>
			//	<div className="content-section introduction">
			//		<div className="feature-intro">
			//			<h1>Lightbox</h1>
			//			<p>LightBox is a modal overlay component to display images, videos and inline content.</p>
			//		</div>
			//	</div>

			//	<div className="content-section implementation">
			//		<h3 className="first">Basic</h3>
			//		<Lightbox type="images" images={images} />

			//		<h3>Content</h3>
			//	</div>
			//</div>
		);
	}
}
const mapStateToProps = state => {
	console.log(state);
	return {
		selectCar: state.carList.selectCar
	};
};

const mapDispatchToProps = dispatch => {
	const { GetCarById } = bindActionCreators(actionCreators, dispatch);
	return {
		GetCarById
	};
};

export default connect(mapStateToProps, mapDispatchToProps)(CarPost);