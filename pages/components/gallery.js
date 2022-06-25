import React, {useState, useEffect} from 'react';
import axios from 'axios';
import InfiniteScroll from "react-infinite-scroll-component";
import Loader from "./loader";


const Gallery = () => {

    /* all photos */
    const [photos, setPhotos] = useState([]);
    /* modal isVisible */
    const [modal, setModal] = useState(false);
    /* clicked image */
    const [tempPhotoUrl, setTempPhotoUrl] = useState('');
    /* clicked image's tag */
    const [tempPhotoTagline, setTempPhotoTagline] = useState('');

    /* calls the fetchImages method the first time the page is loaded */
    useEffect(() => {
        fetchImages();
    }, []);

    /* gets the data from api using axios */
    const fetchImages = () => {
        setModal(false);
        const api = 'https://api.unsplash.com';

        axios
            .get(api + "/photos/?client_id=L6q1dYLzb-AyWQqCAzusi7nSm9ajyQuUshuw9z6X9cE")
            /* waits a second just so you can see the loader, the timeout won't exist in a real project */
            .then(res => setTimeout(() => setPhotos([...photos, ...res.data]), 1000));

    }

    /* sets the photo that will be shown when clicked */
    const photoDetail = (item) => {
        setTempPhotoUrl(item.urls.small);
        setModal(true);
        setTempPhotoTagline("by " + item.user.name);
    };

    /* closes the modal on click to the close button */
    const closeClick = () => {
        setModal(false);
    }

    return (
        <div>
        <div className={modal ? "modal open" : "modal"}>
            <span className={"close"} onClick={() => closeClick()}>&times;</span>
            <div className={"modal-content"}>
                <img src={tempPhotoUrl} style={{height: '90%'}}/>
                <span className={"caption"}>
                    {tempPhotoTagline}
               </span>
            </div>

        </div>
        <InfiniteScroll next={fetchImages} hasMore={true} loader={<Loader />} dataLength={photos.length}>
            <div className="gallery">
                {photos.map((item, index) => {
                    return (<div className="photoItems" onClick={() => photoDetail(item)} key={index}>
                        <img src={item.urls.regular} style={{width: '100%'}} alt={item.tagline}/>
                    </div>)
                })}
            </div>
        </InfiniteScroll>
    </div>
    )
}

export default Gallery;