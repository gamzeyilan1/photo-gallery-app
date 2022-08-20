import React from 'react';

/* Loader animation for when waiting to load images. See global.css for the details. */
 const Loader = () => {
    return (
        <div className={"loader"}>
            <div className="lds-ellipsis">
                <div></div>
                <div></div>
                <div></div>
            </div>
        </div>
    )
}

export default Loader;