import React, { useState, useEffect } from 'react';

const HomePage = () => {
    // רשימת קבצי התמונות
    const images = [
        require('./Image/אאוטסורסינג-2-1021x580.jpg'), // יש להגדיר את כתובת התמונה
        require('./Image/migrated-b7b11bd6bb14a402bdf3be32a648e4f1-31.jpg'),
        require('./Image/EmployeeImage.jpg'),  // הוספת תמונה נוספת
        // ניתן להוסיף עוד תמונות כך
    ];

    // משתנה לאינדקס הנוכחי של התמונה ברשימה
    const [currentImageIndex, setCurrentImageIndex] = useState(0);

    // פונקציה לשינוי התמונה הנוכחית
    const changeImage = () => {
        // בדיקה אם התמונה הנוכחית היא האחרונה ברשימה
        if (currentImageIndex === images.length - 1) {
            // אם כן, נחזור לתמונה הראשונה ברשימה
            setCurrentImageIndex(0);
        } else {
            // אחרת, נעבור לתמונה הבאה
            setCurrentImageIndex(currentImageIndex + 1);
        }
    };

    // השימוש בפונקציה על פי משך הזמן שתרצה
    useEffect(() => {
        // הפעלת הפונקציה כל 5 שניות
        const interval = setInterval(changeImage, 5000);

        // עצירת האינטרוול כאשר הרכיב מוסר מהמסך
        return () => clearInterval(interval);
    }, [currentImageIndex]); // השימוש ב currentImageIndex כדי לוודא שהשינוי באמת יפעיל עדכון בזמן


    return (
        <div style={{
            backgroundImage: `url(${images[currentImageIndex]})`,
            backgroundSize: 'cover',
            backgroundRepeat: 'no-repeat',
            backgroundPosition: 'center',
            width: '100vw',
            height: '100vh',
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center'
        }}>
            <h1 style={{ fontSize: '4em', borderRadius: '10px', backgroundColor: 'rgba(255,255,255,0.5)', padding: '10px', color:'rgb(12 20 117)'  }}>Employee management system</h1>
        </div>
    );
};

export default HomePage;