import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../../store/CarList';

import CarItem  from "./CarItem/CarItem"
class CarList extends Component {
     singleItem = this.props.carList.map(item => {
        return (
            <CarItem
                //id={item.id}
                //key={item.id}             
                name={item.name}
                state={item.state}
                year={item.year}
                img={item.img}
                price={item.price}
                mileage={item.mileage}
            />
        );
    });

    render() {
        return (
            <div className="listCar">
                <div className="container">
                    <div className="row" id="ads">
                        {this.singleItem}
                     </div>
                </div>
            </div>

        );
    }
}
export default connect(
    state => state.carList,
    dispatch => bindActionCreators(actionCreators, dispatch)
)(CarList);