#region License
// Copyright (c) 2014 Bit Rave Pty Ltd
//
// 1. OWNERSHIP, LICENSE GRANT
// Subject to the terms below (the 'License Agreement'), Bit Rave Pty Ltd ('We', 'Us')
// grants you to install and use Azure Mobile Services for Unity (the 'Software').
//
// This is a license agreement and not an agreement for sale. We reserve ownership
// of all intellectual property rights inherent in or relating to the Software,
// which include, but are not limited to, all copyright, patent rights, all rights
// in relation to registered and unregistered trademarks (including service marks),
// confidential information (including trade secrets and know-how) and all rights
// other than those expressly granted by this Agreement.
//
// Subject to the terms and conditions of this License Agreement, We grant to You
// a non-transferable, non-exclusive license for a Designated User (as defined below)
// within Your organization to install and use the Software on any workstations used
// exclusively by such Designated User and for You to distribute the Software as part
// of your Unity applications or games, solely in connection with distribution of
// the Software in accordance with sections 3 and 4 below. This license is not
// sublicensable except as explicitly set forth herein. "Designated User(s)" shall
// mean Your employee(s) acting within the scope of their employment or Your consultant(s)
// or contractor(s) acting within the scope of the services they provide for You or on Your behalf.

// 2. PERMITTED USES, SOURCE CODE, MODIFICATIONS
// We provide You with source code so that You can create Modifications of the original Software,
// where Modification means: a) any addition to or deletion from the contents of a file included
// in the original Software or previous Modifications created by You, or b) any new file that
// contains any part of the original Software or previous Modifications. While You retain all
// rights to any original work authored by You as part of the Modifications, We continue to own
// all copyright and other intellectual property rights in the Software.

// 3. DISTRIBUTION
// You may distribute the Software in any applications, frameworks, or elements (collectively
// referred to as "Applications") that you develop using the Software in accordance with this
// License Agreement, provided that such distribution does not violate the restrictions set
// forth in section 4 of this agreement.

// You will not owe Us any royalties for Your distribution of the Software in accordance with
// this License Agreement.

// 4. PROHIBITED USES
// You may not redistribute the Software or Modifications other than by including the Software
// or a portion thereof within Your own product, which must have substantially different
// functionality than the Software or Modifications and must not allow any third party to use
// the Software or Modifications, or any portions thereof, for software development or application
// development purposes. You are explicitly not allowed to redistribute the Software or
// Modifications as part of any product that can be described as a development toolkit or library
// or is intended for use by software developers or application developers and not end-users.

// 5. TERMINATION
// This Agreement shall terminate automatically if you fail to comply with the limitations
// described in this Agreement. No notice shall be required to effectuate such termination.
// Upon termination, you must remove and destroy all copies of the Software.

// 6. DISCLAIMER OF WARRANTY
// YOU AGREE THAT WE HAVE MADE NO EXPRESS WARRANTIES, ORAL OR WRITTEN, TO YOU REGARDING THE
// SOFTWARE AND THAT THE SOFTWARE IS BEING PROVIDED TO YOU 'AS IS' WITHOUT WARRANTY OF ANY KIND.
//  WE DISCLAIM ANY AND ALL OTHER WARRANTIES, WHETHER EXPRESSED, IMPLIED, OR STATUTORY. YOUR RIGHTS
//  MAY VARY DEPENDING ON THE STATE IN WHICH YOU LIVE. WE SHALL NOT BE LIABLE FOR INDIRECT,
// INCIDENTAL, SPECIAL, COVER, RELIANCE, OR CONSEQUENTIAL DAMAGES RESULTING FROM THE USE OF THIS PRODUCT.

// 7. LIMITATION OF LIABILITY
// YOU USE THIS PROGRAM SOLELY AT YOUR OWN RISK. IN NO EVENT SHALL WE BE LIABLE TO YOU FOR ANY DAMAGES,
// INCLUDING BUT NOT LIMITED TO ANY LOSS, OR OTHER INCIDENTAL, INDIRECT OR CONSEQUENTIAL DAMAGES OF
// ANY KIND ARISING OUT OF THE USE OF THE SOFTWARE, EVEN IF WE HAVE BEEN ADVISED OF THE POSSIBILITY OF
// SUCH DAMAGES. IN NO EVENT WILL WE BE LIABLE FOR ANY CLAIM, WHETHER IN CONTRACT, TORT, OR ANY OTHER
// THEORY OF LIABILITY, EXCEED THE COST OF THE SOFTWARE. THIS LIMITATION SHALL APPLY TO CLAIMS OF
// PERSONAL INJURY TO THE EXTENT PERMITTED BY LAW.

// 8. MISCELLANEOUS
// The license granted herein applies only to the version of the Software available when acquired
// in connection with the terms of this Agreement. Any previous or subsequent license granted to
// You for use of the Software shall be governed by the terms and conditions of the agreement entered
// in connection with the acquisition of that version of the Software. You agree that you will comply
// with all applicable laws and regulations with respect to the Software, including without limitation
// all export and re-export control laws and regulations.
using System;


#endregion


using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Bitrave.Azure;

public class AzureUILeaderboard : MonoBehaviour
{
	private AzureMobileServices azure;
  private int width = 44;
  private int height = 44;
  private int colWidth = 200;
  private Vector2 scrollPosition;
  private int score;

	// Azure product key ran out

  [SerializeField]
  private string AzureEndPoint = "https://tower-defence-leaderboard.azure-mobile.net/"; // Your Connection URL

	[SerializeField]
  private string ApplicationKey = "zDsvAcSdNostwYDAoRBevgPXdHqnRl55"; // Your API Key

	// Table items
	public List<Leaderboard> _leaderboardItems = new List<Leaderboard>();

	// Use this for initialization
	void Start ()
	{
        azure = new AzureMobileServices(AzureEndPoint, ApplicationKey);
        score = PlayerPrefs.GetInt("Score");

  }
	// Item to insert
	private Leaderboard _leaderboard = new Leaderboard()
	{
		PlayerScore = 0,
		PlayerName = "Anon",
	};

	// Item to update
	private Leaderboard _selectedItem = new Leaderboard()
	{
        PlayerScore = 0,
        PlayerName = "Anon",
	};

	public void OnGUI()
    {
		// Column 1
		GUILayout.Label("Name");
		_leaderboard.PlayerName = GUILayout.TextField(_leaderboard.PlayerName);
        GUILayout.Label("Score : " + score);
        _leaderboard.PlayerScore = score;
        if (GUILayout.Button("Submit", GUILayout.MinWidth(width), GUILayout.Height(height)))
        {
            if (_leaderboard.PlayerScore > 0)
            {
                // only insert score if greater than 0
                azure.Insert<Leaderboard>(_leaderboard);
            }
        }
        if (GUILayout.Button("Main Menu", GUILayout.MinWidth(width), GUILayout.Height(height)))
        {
            Application.LoadLevel(0);
        }
        GUILayout.BeginVertical();
        if (GUILayout.Button("Show Leaderboard", GUILayout.MinWidth(width), GUILayout.Height(height)))
        {
            GetAllItems();
            GUILayout.Label("Leaderboard :");
        }
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, false, true, GUILayout.Height(300));
        foreach (var item in _leaderboardItems)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(item.PlayerName);
            GUILayout.Label(Convert.ToString(item.PlayerScore));
            GUILayout.EndHorizontal();
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
    }

	public void GetAllItems()
	{
		_leaderboardItems.Clear();
		azure.Where<Leaderboard>(p => p.PlayerName != null, ReadHandler);
	}

	public void ReadHandler(AzureResponse<List<Leaderboard>> response)
	{

		var list = response.ResponseData;

		Debug.Log("Items ==================");
		foreach (var item in list)
		{
			Debug.Log( Convert.ToString(item.PlayerScore) + "," + item.PlayerName + "," + item.Id);
			_leaderboardItems.Add(item);
		}
		Debug.Log("==================");
	}

}
